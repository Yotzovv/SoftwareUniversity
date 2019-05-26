import RequestData from "./request";

declare var require: NodeRequire;

let myData = new RequestData('GET',
'http://google.com', 'HTTP/1.1', '');

console.log('myData');