import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numberToArray'
})
export class NumberToArrayPipe implements PipeTransform {

  transform(value: number): number[] {
    let arr = [];
    arr.push(value)
    return arr;
  }

}
