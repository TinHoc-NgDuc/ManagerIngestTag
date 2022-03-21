using ManagerIngest.Infrastructure;
using ManagerIngest.Models;
using ManagerIngestTag.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumaryIngestController : ControllerBase
    {
        private readonly DataContext _context;
        public SumaryIngestController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<SumaryIngestController>
        [HttpGet]
        public IEnumerable<SummaryIngest> Get()
        {
            List<SummaryIngest> result = new();
            //select all ticket
            var query = from tk in _context.TicketIngests
                        select new TicketIngestModel
                        {
                            TicketIngestId = tk.TicketIngestId,
                            Name = tk.Name,
                            CreateName = tk.CreateName,
                            TopicName = tk.TopicName,
                            ProgramName = tk.ProductionName,
                            CameramanName = tk.CameramanName,
                            ProductionName = tk.ProductionName,
                            ReporterName = tk.ReporterName,
                            SaveDocument = tk.SaveDocument,
                            IsReporting = tk.IsReporting,
                            IsNew = tk.IsNew,
                            IsCategory = tk.IsCategory,
                            IsOtherProgram = tk.IsOtherProgram,
                            StatusIngest = tk.StatusIngest
                        };
            var data = query.ToList();
            //get all ticket 
            foreach (var item in data)
            {
                SummaryIngest summary = new();
                summary.ticketIngest = new TicketIngestFull
                {
                    TicketIngestId = item.TicketIngestId,
                    Name = item.Name,
                    CreateName = item.CreateName,
                    TopicName = item.TopicName,
                    ProgramName = item.ProductionName,
                    CameramanName = item.CameramanName,
                    ProductionName = item.ProductionName,
                    ReporterName = item.ReporterName,
                    SaveDocument = item.SaveDocument,
                    IsReporting = item.IsReporting,
                    IsNew = item.IsNew,
                    IsCategory = item.IsCategory,
                    IsOtherProgram = item.IsOtherProgram,
                    StatusIngest = item.StatusIngest,

                };

                summary.ticketIngest.StatusName = (from st in _context.StatusIngests
                                                   where st.StatusCode.Contains(item.StatusIngest)
                                                   select new StatusIngestModel
                                                   {
                                                       Name = st.Name,
                                                       StatusCode = st.StatusCode,
                                                       StatusIngestId = st.StatusIngestId
                                                   }).ToList().FirstOrDefault().Name;
                var query2 = from id in _context.IngestDetails
                             where id.ticketIngest.TicketIngestId == item.TicketIngestId
                             select new IngestDetailFull
                             {
                                 IngestDeltailId = id.IngestDeltailId,
                                 DateReturn = id.DateReturn,
                                 DateSend = id.DateSend,
                                 IngestTagId = id.IngestTag.IngestTagId,
                                 RecipientName = id.RecipientName,
                                 TakerName = id.TakerName,
                                 TakerId = id.TakerId,
                                 Status = id.Status,
                                 ticketIngestId = id.ticketIngest.TicketIngestId,
                                 RecipientId = id.RecipientId,
                                 IngestTag = new IngestTagReturnModel
                                 {
                                     IngestTagId = id.IngestTag.IngestTagId,
                                     IngestCode = id.IngestTag.IngestCode,
                                     Name = id.IngestTag.Name,
                                     Note = id.IngestTag.Note,
                                     Status = id.IngestTag.Status,
                                     CategoryId = id.IngestTag.category.CategoryId,
                                     cardholderId = id.IngestTag.cardholderId,
                                     EmployeeId = id.IngestTag.Employee.EmployeeId,
                                     CardholderName = id.IngestTag.Employee.Name,
                                     CategoryName = id.IngestTag.category.Name
                                 }
                             };
                summary.ingestDetail = query2.ToList();
                summary.ticketIngest.IngestDetailFull = summary.ingestDetail;

                var query3 = from history in _context.HistoryIngests
                             where (history.TicketIngest.TicketIngestId == item.TicketIngestId)
                             orderby history.TimeAction
                             select new HistoryIngestModel
                             {
                                 HistoryIngestId = history.HistoryIngestId,
                                 TimeAction = history.TimeAction,
                                 TicketIngestId = history.TicketIngest.TicketIngestId,
                                 Performer = history.Performer,
                                 NameAction = history.NameAction,
                                 ActionCode = history.ActionCode,
                                 IngestDetailId = history.IngestDetail.IngestDeltailId
                             };
                summary.HistoryIngest = query3.ToList();
                result.Add(summary);
            }

            return result;
        }

        //Get api/SumaryIngestController/exportExcel
        [HttpGet("exportExcel")]
        public async Task<ActionResult<SummaryIngest>> GetExport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    
                    // đặt tên người tạo file
                    //p.Workbook.Properties.Author = "";

                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("Bảng tổng hợp Ingest");
                    
                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[0];

                    // đặt tên cho sheet
                    ws.Name = "summary ingest";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 11;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "STT",
                                                "Trạng thái",
                                                "Ngày",
                                                "Tên đề tài",
                                                "Phóng viên",
                                                "Quay Phim",
                                                "Thể loại Ingest",
                                                "Lưu tư liệu",
                                                "Thể loại",
                                                "Thông tin chi tiết",
                                                "Người nhận thẻ"
                    };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "Bảng thông tin chi tiết các phiếu Ingest";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                        //gán giá trị
                        cell.Value = item;

                        colIndex++;
                    }

                    // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                    //List<UserInfo> userList = dtgExcel.ItemsSource.Cast<UserInfo>().ToList();

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    //foreach (var item in userList)
                    //{
                    //    // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                    //    colIndex = 1;

                    //    // rowIndex tương ứng từng dòng dữ liệu
                    //    rowIndex++;

                    //    //gán giá trị cho từng cell                      
                    //    ws.Cells[rowIndex, colIndex++].Value = item.Name;

                    //    // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                    //    ws.Cells[rowIndex, colIndex++].Value = item.Birthday.ToShortDateString();

                    //}

                    //Lưu file lại
                    //Byte[] bin = p.GetAsByteArray();
                    //File.WriteAllBytes(filePath, bin);
                    HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    FileContentResult result = new FileContentResult(p.GetAsByteArray(),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = "otherfile.xlsx"
                    };
                    return result;
                }

            }
            catch (Exception EE)
            {
                return NoContent();
            }
        }

        // PUT api/<SumaryIngestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SumaryIngestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
