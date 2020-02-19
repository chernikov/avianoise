import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'fileFormat'
})
export class FileFormatPipe implements PipeTransform {

  transform(value: string): string {
    return value.split('.').pop();;
  }

}
