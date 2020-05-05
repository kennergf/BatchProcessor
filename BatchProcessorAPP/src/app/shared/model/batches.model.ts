import { Deserializable } from './deserializable.model';
import { Unit } from './unit.model';

export class Batches implements Deserializable {
    batches: Array<Array<Unit>>;
    remainingNumbers: number;
    currentTotal: number;
    grandTotal: number;

    deserialize(data: any) {
        Object.assign(this, data);
        this.batches = data.numbers;
        // Iterate over numbers and deserialize one by one
        // this.batches = input.numbers.map(bt => new Batches().deserialize(bt)
        // );
        // console.log('final');
        // console.log(this as BatchLot);
        return this;
    }
}