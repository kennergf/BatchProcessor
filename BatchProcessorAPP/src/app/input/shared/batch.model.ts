import { Deserializable } from './deserializable.model';

export class Batch implements Deserializable {
    number: number;
    total: number;

    deserialize(input: any): this {
        return Object.assign(this, input);
    }
}
