import { Deserializable } from './deserializable.model';

export class Unit implements Deserializable {
    number: number;
    total: number;

    deserialize(data: any): this {
        return Object.assign(this, data);
    };
}
