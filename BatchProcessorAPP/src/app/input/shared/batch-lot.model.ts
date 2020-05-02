import { Batches } from './batches.model';
import { Deserializable } from './deserializable.model';

export class BatchLot implements Deserializable {
    batches: Batches[];
    remainingNumbers: number;
    grandTotal: number;

    deserialize(input: any){
        Object.assign(this, input);
        // Iterate over numbers and deserialize one by one
        this.batches = input.numbers.map(bt => new Batches().deserialize(bt));
        return this;
    }
}
