import { Batches } from './batches.model';
import { Deserializable } from './deserializable.model';

export class BatchLot implements Deserializable {
    batches: Batches[];
    remainingNumbers: number;
    currentTotal: number;
    grandTotal: number;

    deserialize(input: any){
        console.log('Batch-lot');
        console.log(input);
        Object.assign(this, input);
        // Iterate over numbers and deserialize one by one
        this.batches = input.numbers.map(bt => new Batches().deserialize(bt)
        );
        console.log('final');
        console.log(this as BatchLot);
        return this;
    }
}
