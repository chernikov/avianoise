import { ExtendedFile } from '@classes/extended-file.class';

export class ProxyExtendedFile extends ExtendedFile {
    isSelect: boolean = false;
    isDecoding: boolean = false;
    isDeleting: boolean = false;
}