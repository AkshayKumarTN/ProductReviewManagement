using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();
        public Management()
        {
            // Creating Columns of the DataTable.................
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));

            // Inserting Data into the Table.....................
            dataTable.Rows.Add(1, 1, 2d, "Good", true);
            dataTable.Rows.Add(2, 1, 4d, "Good", true);
            dataTable.Rows.Add(3, 1, 5d, "Good", true);
            dataTable.Rows.Add(4, 1, 6d, "Good", false);
            dataTable.Rows.Add(5, 1, 2d, "nice", true);
            dataTable.Rows.Add(6, 1, 1d, "bas", true);
            dataTable.Rows.Add(8, 1, 1d, "Good", false);
            dataTable.Rows.Add(8, 1, 9d, "nice", true);
            dataTable.Rows.Add(2, 1, 10d, "nice", true);
            dataTable.Rows.Add(10, 1, 8d, "nice", true);
            dataTable.Rows.Add(11, 1, 3d, "nice", true);
        }

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

        // Method to Retrieve records where isLike is true in data table...........
        public void RetrieveTrueIsLike()
        {
            var Data = from reviews in dataTable.AsEnumerable()
                       where reviews.Field<bool>("isLike").Equals(true)
                       select reviews;
                       
            foreach (var dataItem in Data)
            {
                Console.WriteLine($"ProductID- {dataItem.ItemArray[0]} UserID- {dataItem.ItemArray[1]} Rating- {dataItem.ItemArray[2]} Review- {dataItem.ItemArray[3]} isLike- {dataItem.ItemArray[4]}");
            }
        }

        // Method to Get Average Rating of each ProductID in DataTable..............
        public void AverageRatingByProductID()
        {
            var Data = dataTable.AsEnumerable()
                        .GroupBy(x => x.Field<int>("ProductID"))
                        .Select(x => new { ProductID = x.Key, Average = x.Average(p => p.Field<double>("Rating")) });
            foreach (var dataItem in Data)
            {
                Console.WriteLine(dataItem.ProductID + " " + dataItem.Average);
            }
        }

        // Method to Retrieve All Reviews Having nice in them.................
        public void NiceReviews()
        {
            var Data = dataTable.AsEnumerable()
                        .Where(x => x.Field<string>("Review").Contains("Nice", StringComparison.OrdinalIgnoreCase));
            foreach (var dataItem in Data)
            {
                foreach (var item in dataItem.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
