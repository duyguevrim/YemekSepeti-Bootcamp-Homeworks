using System;

namespace CleanCodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCompleted = true;
            if (isCompleted)
            {
                Console.WriteLine("Boolean karsilastirmalar : completed == false yerine bu sekilde yazmamiz daha kolay");
            }


            int totalProcessCount = 150;
            bool isDone = totalProcessCount == 150;
            Console.WriteLine("Boolean Değer Atamaları : " + isDone);


            if (isCompleted)
            {
                Console.WriteLine("mumkun oldugunca pozitif ifadeler kullanmamiz gerekir.");
            }



            bool isProAccount = false;
            int totalPostLimit = isProAccount ? 1000 : 3;
            Console.WriteLine("Ternary IF kullanımı : " + totalPostLimit);


            // Başıboş ifadelerden kaçınmalıyız. Aşağıdaki kodda bulunan 10 sayısının neyi temsil ettiğini bilmiyoruz.
            // bu durum kodun anlaşılırlığını bozacatır.

            int totalPost = 16;
            if (!isProAccount && totalPost > 3)
            {
                Console.WriteLine("Yeni post için pro hesaba geçmeniz gerekmektedir.");
                Console.WriteLine("Başı boş ifadelerden kaçınma örneği");
            }

            //bir örnek daha
            int totalLike = 5;
            if (totalLike > 10)
            {
                Console.WriteLine("yanlış kullanım");
            }

            int totalLikeLimit = 10;
            if (totalLike > totalLikeLimit)
            {
                Console.WriteLine("doğru kullanım");
            }



            Console.WriteLine("Karmaşık koşulları sadeleştir ve anlamlandır");
            DateTime lastLoginWithToken = DateTime.Now;
            int FBAccountCount = 5;
            int totalAccountCount = 7;
            bool isFaceboFBAccount = totalAccountCount - FBAccountCount > 0 && totalPost > 0;
            if (isFaceboFBAccount) 
            {
                Console.WriteLine("FB Hesabı kabul edilebilir");
            }


            //karşılaştırma işlemi yaparken lowercase veya uppercase verilere göre yanlış sonuçlar çıkabilir. 
            // reference üzerinden karşılaştırma yapmak hata olasılığımızı yok eder.
            //string accountType;

            //if (accountType == "Facebook")
            //{
            //    Console.WriteLine("yanlış kullanım");
            //}
            //if(accountType == accountTypes.Facebook)
            //{
            //    Console.WriteLine("doğru kullanım");
            //}



            //LINQ Kullanımı
            //Aşağıdaki kullanım LINQ kullanımına göre çok daha karmaşıktır.
            //List<Posts> postsList = new List<Posts>();

            //foreach (var post in posts)
            //{
            //    if (post.IsActive &&
            //       post.Status == PostStatus.Pending)
            //    {
            //        postsList.Add(post);
            //    }
            //}

            //return postsList;

            //Bunun yerine aşağıdaki kullanım çok daha anlaşılır ve basittir
            //return posts.Where(p => p.IsActive && p.Status == ContractStatus.Pending);



            //Değişken Kullanımı
            // Methodlarda değişken tanımlamaları ilk değer atamasından hemen önce yapılmalı. ( Just-in-time )
            // böylece takibi daha kolay olur

            //yanlış
            //int minAcceptedYear = 5;
            //int maxAcceptedYear = 15;

            //if (employee.year < minAcceptedYear)
            //    return false;
            //if (employee.year > maxAcceptedYear)
            //    return false;

            //------------------------------------------------------------
            // doğru
            //int minAcceptedYear = 5;
            //if (employee.year < minAcceptedYear)
            //    return false;

            //int maxAcceptedYear = 15;
            //if (employee.year > maxAcceptedYear)
            //    return false;



            //parametre kullanımı
            // Fazla parametre alan methodlarımız parçalanmalı veya parametre olarak Model almalıdır.

            // yanlış
            //public void publishPost(string userName,
            //         string password,
            //         string email,
            //         string message,
            //         string accountAccessToken,
            //         DateTime publishTime
            //         bool sendEmail,
            //         bool printReport)
            //{

            //}

            //doğru
            //public void publishPost(
            //         string message,
            //         string accountAccessToken,
            //         DateTime publishTime
            //{

            //}


            //Karmaşıklık ve Girinti Problemi
            // Kod parçalarındaki iç içelik arttıkça karmaşıklık da artacaktır. Kodun anlaşılırlığı kalmayacaktır.

            //yanlış kullanım
            //if ()
            //{
            //    if ()
            //    {
            //        do
            //        {

            //        } while ()
            //    }
            //}

            //doğru kullanım
            //if ()
            //{
            //    if ()
            //    {
            //        PostControl();
            //    }
            //}


            //private void PostControl()
            //{
            //    do
            //    {
            //        Bu kısma gerekli kod parçası yazılır
            //    } while ()
            //}



            //Fail Fast ? Eğer kodda hata fırlatıyorsak, hata fırlatma işlemini kod bloğundan önce yapmamız gerekir.
            //yanlış
            //         public void publishPost(string postMessage,
            //                 string accountAccessToken,
            //                 Datetime publishingDate)
            //         {
            //             if (!string.IsNullOrWhiteSpace(postMessage))
            //             {
            //                 // kod
            //                 if (!string.IsNullOrWhiteSpace(accountAccessToken))
            //                 {

            //                 }
            //                 else
            //                 {
            //                     throw ...
            //   }
            //             }
            //             else
            //             {
            //                 throw ...
            //}

            //doğru
            //public void publishPost(string postMessage,
            //                 string accountAccessToken,
            //                 Datetime publishingDate)
            //{
            //    if (string.IsNullOrWhiteSpace(postMessage))
            //        throw ...;
            //    if (string.IsNullOrWhiteSpace(accountAccessToken))
            //        throw ...;

            //    // post atma işlemi;
            //}



            // Return Early ? fail fasttaki durumların hepsi burada da geçerli. 
            // Methodun işleyişine göre return edilebilecek değerlerin öncelikli olarak geri dönülmesi ile uygulanır.

            //yanlış kullanım
            //private bool ValidEmployee(string employeeName)
            //{
            //    int minAcceptedYear = 5;
            //    int maxAcceptedYear = 15;
            //    bool isValid = false;

            //    if (EmployeeControl.year >= minAcceptedYear)
            //    {
            //        if (Employee.year <= maxAcceptedYear)
            //        {
            //            bool isAlphaNumeric = employeeName.All(Char.IsLetterOrDigit);
            //            if (isAlphaNumeric)
            //            {
            //                if (!ContainsCurseWords(employeeName))
            //                {
            //                    isValid = IsUniqueUserName(employeeName);
            //                }
            //            }
            //        }
            //    }
            //    return isValid;
            //}



            //doğru kullanım
            //private bool ValidEmployee(string employeeName)
            //{
            //    int minAcceptedYear = 5;
            //    if (employee.year < minUserNameLength)
            //        return false;
            //    int maxAcceptedYear = 15;
            //    if (employee.year > maxUserNameLength)
            //        return false;
            //    bool isAlphaNumeric = employeeName.All(Char.IsLetterOrDigit);
            //    if (!isAlphaNumeric)
            //        return false;

            //    if (ContainsCurseWords(employeeName))
            //        return false;

            //    return IsUniqueUserName(employeeName);
            //}
        }
    }
}
