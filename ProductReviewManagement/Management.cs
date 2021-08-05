﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();
        // Method to retrieve top 3 rated reviews............
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview 
                                orderby productReview.Rating descending
                                select productReview).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }

        // Method to retrieve products with given rating and id................
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               where (productReview.ProductID == 1 || productReview.ProductID == 4 || productReview.ProductID == 9)
                               && productReview.Rating > 3
                               select productReview;
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }

        // Method to Count Reviews By Product ID..................
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Count);
            }
        }

        // Method to Retrieve Only ProductID and Reviews.................
        public void RetrieveProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               select new { productReview.ProductID, productReview.Review };
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Review);
            }
        }

        // Method to Skip Top 5 Reviews and display the remaining.............
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                select productReview).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }

        // Method to Retrieve ProductId and Reviews using LINQ select..............
        public void SelectProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { x.ProductID, x.Review });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Review);
            }
        }
    }
}
