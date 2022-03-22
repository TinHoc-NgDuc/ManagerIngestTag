// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  baseUrl : 'https://localhost:5001',

  // status tag
  Darft:'Darft',
  Pending:'Pending',
  SentFile:'Senfile',
  ReturnTag:'ReturnTag',
  Approved:'Approved',

  //status messeger
  Error:"Error",
  Success:"success",
  Warring:"Warring"
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invsuccesseTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
