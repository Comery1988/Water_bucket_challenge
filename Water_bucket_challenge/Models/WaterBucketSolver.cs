namespace Water_bucket_challenge.Models
{
    public class WaterBucketSolver
    {
        private readonly BucketsAction _BucketsAction;

        public WaterBucketSolver()
        {
            _BucketsAction = new BucketsAction();
        }

        /*
         * Function to carry out the steps to follow to obtain the best solution, for this two 
         * lists of buckets are created stepsX, for the steps started with bucket X and stepsY, 
         * for the steps started with bucket Y. When any of the two paths reaches its end, the cycle 
         * ends, it is verified which of the two was the one that reached the objective and those 
         * steps are returned as the best solution
         */
        public List<Buckets> Solve(Gallons gallons)
        {
            // List of buckets to store the two ways to go
            List<Buckets> stepsX = new List<Buckets>();
            List<Buckets> stepsY = new List<Buckets>();

            // 4 bucket objects are created, 2 for each path to follow.
            BucketState bucketXstepX = new BucketState { Capacity = gallons.X_Gallon };
            BucketState bucketYstepX = new BucketState { Capacity = gallons.Y_Gallon };

            BucketState bucketXstepY = new BucketState { Capacity = gallons.X_Gallon };
            BucketState bucketYstepY = new BucketState { Capacity = gallons.Y_Gallon };

            // Loop to perform the actions until the goal is reached
            while (bucketXstepX.CurrentVolume != gallons.Z_Gallon && bucketYstepX.CurrentVolume != gallons.Z_Gallon && bucketXstepY.CurrentVolume != gallons.Z_Gallon && bucketYstepY.CurrentVolume != gallons.Z_Gallon)
            {
                stepsX.Add(_BucketsAction.Action(gallons, bucketXstepX, bucketYstepX, true));

                stepsY.Add(_BucketsAction.Action(gallons, bucketYstepY, bucketXstepY, false));
            }

            // Verification of which path reached the objective
            if (bucketXstepX.CurrentVolume == gallons.Z_Gallon || bucketYstepX.CurrentVolume == gallons.Z_Gallon)
            {
                return stepsX;
            }
            else
            {
                return stepsY;
            }
        }
    }
}
