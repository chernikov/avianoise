import { Pipe, PipeTransform } from "@angular/core";
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'sanitizeHtml'
})
export class SanitizeHtmlPipe implements PipeTransform {

  constructor(private _sanitizer:DomSanitizer) {
  }

  transform(value:string):SafeHtml {
    let data = value.replace('<img', '<img style="max-width: 100%"');
    return this._sanitizer.bypassSecurityTrustHtml(data);
  }
}