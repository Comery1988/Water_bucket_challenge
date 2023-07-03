namespace Water_bucket_challenge.Models
{
    /*
     * Class to manipulate the state of the buckets
     */
    public class BucketState
    {
        public int Capacity { get; set; }
        public int CurrentVolume { get; set; }

        /*
         * Function to check if a bucket is at its maximum capacity
         */
        public bool IsFull()
        {
            return CurrentVolume == Capacity;
        }

        /*
         * Function to check if a bucket is empty
         */
        public bool IsEmpty()
        {
            return CurrentVolume == 0;
        }

        /*
         * Function to fill a bucket to its maximum capacity
         */
        public void Fill()
        {
            CurrentVolume = Capacity;
        }

        /*
         * Function to empty a bucket
         */
        public void Empty()
        {
            CurrentVolume = 0;
        }
    }
}
