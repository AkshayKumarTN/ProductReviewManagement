using System;
using System.Collections.Generic;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Product Review Management");
            Console.WriteLine("------------------------------------------------------------------");

            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=2,Review="Good",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductID=3,UserID=1,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductID=4,UserID=1,Rating=6,Review="Good",isLike=false},
                new ProductReview(){ProductID=5,UserID=1,Rating=2,Review="nice",isLike=true},
                new ProductReview(){ProductID=6,UserID=1,Rating=1,Review="bas",isLike=true},
                new ProductReview(){ProductID=8,UserID=1,Rating=1,Review="Good",isLike=false},
                new ProductReview(){ProductID=8,UserID=1,Rating=9,Review="nice",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=10,Review="nice",isLike=true},
                new ProductReview(){ProductID=10,UserID=1,Rating=8,Review="nice",isLike=true},
                new ProductReview(){ProductID=11,UserID=1,Rating=3,Review="nice",isLike=true}
            };

            Management management = new Management();
            //  top 3 rated reviews Method.................
            management.TopRecords(productReviewList);
            Console.WriteLine("------------------------------------------------------------------");
            // Products with given rating and id...............
            management.SelectedRecords(productReviewList);
            Console.WriteLine("------------------------------------------------------------------");
            // Count Reviews By Product ID....................
            management.RetrieveCountOfRecords(productReviewList);
            Console.WriteLine("------------------------------------------------------------------");
            // Retrieve Only ProductID and Reviews...............
            management.RetrieveProductIDAndReviews(productReviewList);
            Console.WriteLine("------------------------------------------------------------------");
            // Skip Top 5 Reviews and display the remaining............
            management.SkipTop5Records(productReviewList);
            Console.WriteLine("------------------------------------------------------------------");
            // Retrieve ProductId and Reviews using LINQ select............
            management.SelectProductIDAndReviews(productReviewList);
        }
    }
}
