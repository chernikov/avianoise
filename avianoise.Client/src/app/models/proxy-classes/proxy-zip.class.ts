import { Zip } from '@classes/zip.class';

export class ProxyZip extends Zip {
    isUnpacking: boolean = false;
    isDeleting: boolean = false;
}