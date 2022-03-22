import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-notitfy',
  templateUrl: './notitfy.component.html',
  styleUrls: ['./notitfy.component.css']
})
export class NotitfyComponent implements OnInit {
  public messeger : Messeger = new Messeger();

  public Error =  environment.Error;
  public Success =  environment.Success;
  public Warring =  environment.Warring;


  constructor() { }

  ngOnInit(): void {
    this.messeger.title = "Thành công";
    this.messeger.messeger = "Thêm thành công!";
    this.messeger.status = this.Success;

  }

}
class Messeger {
  public title: string = "";
  public messeger: string = "";
  public status: string = "";
}