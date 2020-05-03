import { Deserializable } from './deserializable.model';

export class Batch implements Deserializable {
    number: number;
    total: number;

    deserialize(input: any): this {
        console.log('Batch');
        console.log(input);
        return Object.assign(this, input);
    }
}
