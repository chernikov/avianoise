import { File } from '@classes/file.class';
import { ProxyLine } from './proxy-line.class';

export class ProxyFile extends File {
    isSelect: boolean = false;
    lines: ProxyLine[];
}