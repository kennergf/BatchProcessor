import { Batch } from './batch.model';

export class Batches {
    numbers: Batch[];

    deserialize(input: any){
        Object.assign(this, input);
        console.log(input);
        // Iterate over numbers and deserialize one by one
        this.numbers = input.map(number => new Batch().deserialize(number));
        return this;
    }
}
