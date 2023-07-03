##Project Name: 
#Water Bucket Challenge

###Description:
This project is an API to solve the problem of gallons of water, in which the values of X, Y and Z are received through POST to solve the assigned problem.

In this API, a controller is implemented that receives the values, which are evaluated under the specified conditions (that are positive integers), to later evaluate if the combination has a solution or not, this is determined under the following 3 conditions:
1. Check that X and Y are greater than Z
2. Verify that if X and Y are equal, they are also equal to Z
3. Check if the greatest common divisor of X and Y can divide Z

If these three conditions are possible, the combination has a solution, this problem has 2 ways to solve which consists of filling a bucket and filling the other bucket until it is full, refilling the first bucket if it runs out of water and emptying the second bucket if it is filled, this until reaching the required value, this process begins by first filling X or Y (these would be the two paths).

In the project, a function is implemented that starts both paths until one of the two reaches the goal, when the goal is reached, the list of steps that first reached Z is returned.

###Setup
-Clone this repository to your local machine.
-Open the project in your preferred development environment.
-Build the project.

###Use
-Run the app from your development environment or via command line.
-Test service responses with swagger

###License
This project is under a free license.