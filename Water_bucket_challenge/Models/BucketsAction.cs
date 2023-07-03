using Water_bucket_challenge.Models;

namespace Water_bucket_challenge.Models
{
    public class BucketsAction
    {
        /*
         * Function for the action of the buckets, in this the number of gallons inserted by the 
         * user (X, Y and Z) in the Gallons object, the states of the buckets X and Y are received 
         * in the BucketState objects and a boolean value to identify if it corresponds to the sequence 
         * of steps of bucket X or not. This function makes a decision based on the current situation 
         * of the buckets to carry out the corresponding action and returns the resulting states of 
         * the buckets and the description of the action based on the 3 possible movements 
         * (Fill, Transfer and Empty).
         */
        public Buckets Action(Gallons gallons, BucketState bucket1, BucketState bucket2, bool firstX)
        {
            /* 
             * States of the buckets based on the condition of the bool, since the texts will depend on 
             * whether the action corresponds to the steps of having started with X or not
            */
            string state1 = firstX ? "Fill bucket X" : "Fill bucket Y"; // Fill
            string state2 = firstX ? "Transfer bucket X to bucket Y" : "Transfer bucket Y to bucket X"; // Transfer
            string state3 = firstX ? "Empty bucket Y" : "Empty bucket X"; // Empty

            /*
             * Decision making based on the current situation of the buckets
             */
            if (!bucket2.IsFull())
            {
                if (bucket1.IsEmpty())
                {
                    /*
                     * If the receiving bucket is not full and the sending bucket is empty, the sending 
                     * bucket is filled and the current values are returned with the filling description
                     */
                    bucket1.Fill();
                    return new Buckets
                    {
                        Bucket_X = firstX ? bucket1.CurrentVolume : bucket2.CurrentVolume,
                        Bucket_Y = firstX ? bucket2.CurrentVolume : bucket1.CurrentVolume,
                        Explanation = bucket1.CurrentVolume == gallons.Z_Gallon ? state1 += ". Solved" : state1
                    };
                }
                else
                {
                    /*
                     * If the receiving bucket is not full and the sending bucket is not empty, 
                     * we proceed to verify what number of gallons can pass from the sending bucket 
                     * to the receiver, said quantity is decreased to the sender, it is increased 
                     * to the receiver and the current values are returned. with the description of transfer
                     */
                    int amountToTransfer = bucket1.CurrentVolume <= (bucket2.Capacity - bucket2.CurrentVolume)
                    ? bucket1.CurrentVolume
                    : (bucket2.Capacity - bucket2.CurrentVolume);

                    bucket1.CurrentVolume -= amountToTransfer;
                    bucket2.CurrentVolume += amountToTransfer;
                    return new Buckets
                    {
                        Bucket_X = firstX ? bucket1.CurrentVolume : bucket2.CurrentVolume,
                        Bucket_Y = firstX ? bucket2.CurrentVolume : bucket1.CurrentVolume,
                        Explanation = bucket1.CurrentVolume == gallons.Z_Gallon ? state2 += ". Solved" : state2
                    };
                }

            }
            else
            {
                /*
                 * If the receiving bucket is full, it proceeds to empty it and the current values 
                 * are returned with the emptying description
                 */
                bucket2.Empty();
                return new Buckets {
                    Bucket_X = firstX ? bucket1.CurrentVolume : bucket2.CurrentVolume,
                    Bucket_Y = firstX ? bucket2.CurrentVolume : bucket1.CurrentVolume,
                    Explanation = state3 
                };
            }
        }

    }
}
