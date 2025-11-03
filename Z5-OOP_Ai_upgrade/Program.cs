using ekim27_2.Entities;
using ekim27_2.Interfaces;
using ekim27_2.Repository;
using System;

namespace ekim27_2
{
    public class Program
    {
        // IBaseEntity, IBaseEntity, Author, Post, Category, Comment

        static void Main(string[] args)
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            ICategoryRepository categoryRepository = new CategoryRepository();
            ICommentRepository commentRepository = new CommentRepository();
            IMemberRepository memberRepository = new MemberRepository();
            IPostRepository postRepository = new PostRepository();

            BaseUser currentUser = null;

            do
            {
                if (currentUser == null)
                {
                    Console.WriteLine("1-Kayıt Ol\n2-Giriş Yap\n3-Çıkış");
                    Console.Write("seçim: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("1-Author\n2-Member");
                            Console.Write("seçim: ");
                            string membershipChoice = Console.ReadLine();

                            Console.Write("Ad: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Soyad: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Kullanıcı Adı: ");
                            string username = Console.ReadLine();

                            Console.Write("Şifre: ");
                            string password = Console.ReadLine();

                            if (membershipChoice == "1")
                            {
                                Console.Write("Title: ");
                                string title = Console.ReadLine();

                                var author = new Author()
                                {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Username = username,
                                    Password = password,
                                    Title = title
                                };

                                authorRepository.Create(author);
                                break;
                            }

                            var member = new Member()
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Username = username,
                                Password = password,
                            };

                            memberRepository.Create(member);
                            break;
                        case "2":
                            Console.WriteLine("1-Author\n2-Member");
                            Console.Write("seçim: ");
                            string loginCohice = Console.ReadLine();

                            Console.Write("Kullanıcı Adı: ");
                            string loginUsername = Console.ReadLine();

                            Console.Write("Şifre: ");
                            string loginPassword = Console.ReadLine();

                            if (loginCohice == "1")
                            {
                                var loginAuthor = authorRepository.GetByUsername(loginUsername);
                                if (loginAuthor.Password == loginPassword)
                                {
                                    currentUser = loginAuthor;
                                }
                                break;
                            }

                            var loginMember = memberRepository.GetByUsername(loginUsername);
                            if (loginMember.Password == loginPassword)
                            {
                                currentUser = loginMember;
                            }

                            break;
                        case "3":
                            return;

                        default:
                            Console.WriteLine("Yanlış seçin yaptınız lütfen tekrar ediniz:");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("======Post İşlemleri======");
                    Console.WriteLine("1-Post Ekle\n2-Post Güncelle\n3-Post sil\n4-Post Listele");
                    Console.WriteLine("======Category İşlemleri======");
                    Console.WriteLine("5-Category Ekle\n6-Category Güncelle\n7-Category sil\n8-Category Listele");
                    Console.WriteLine("======Comment İşlemleri======");
                    Console.WriteLine("9-Comment Ekle\n10-Comment Güncelle\n11-Comment sil\n12-Comment Listele");
                    Console.Write("seçim: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            if (currentUser is Author)
                            {
                                Console.Write("Başlık: ");
                                string title = Console.ReadLine();

                                Console.Write("İçerik: ");
                                string body = Console.ReadLine();

                                postRepository.Create(new Post() { Title = title, Body = body, Author = currentUser as Author});
                                Console.WriteLine("Post oluşturuldu");
                            } else
                            {
                                Console.WriteLine("Post Ekleyemezsiniz.");
                            }

                            break;
                        case "2":
                            if (currentUser is Author)
                            {
                                Console.Write("Post Id: ");
                                Guid updatedPostId = Guid.Parse(Console.ReadLine());

                                Console.Write("Başlık: ");
                                string updatedTitle = Console.ReadLine();

                                Console.Write("İçerik: ");
                                string updatedBody = Console.ReadLine();

                                var updatedPost = postRepository.Get(updatedPostId);

                                postRepository.Update(updatedPost);
                                Console.WriteLine("Post güncellendi");
                            }
                            else
                            {
                                Console.WriteLine("Post Ekleyemezsiniz.");
                            }
                            break;
                        case "3":
                            if (currentUser is Author)
                            {
                                Console.Write("Post Id: ");
                                Guid deletedPostId = Guid.Parse(Console.ReadLine());

                                var deletedPost = postRepository.Get(deletedPostId);

                                postRepository.Update(deletedPost);
                                Console.WriteLine("Post Silindi");
                            }
                            else
                            {
                                Console.WriteLine("Post Sil.");
                            }
                            break;
                        case "4":
                            var posts = postRepository.GetAll();
                            foreach (var post in posts)
                            {
                                Console.WriteLine(post);
                            }

                            break;
                        case "5":
                            Console.Write("Kategori İsmi: ");
                            string categoryName = Console.ReadLine();


                            categoryRepository.Create(new Category() { Name = categoryName});
                            Console.WriteLine("Category oluşturuldu");
                            break;
                        case "6":
                            Console.Write("Category Id: ");
                            Guid updatedCategoryId = Guid.Parse(Console.ReadLine());

                            Console.Write("Kategori İsmi: ");
                            string updatedCtegoryName = Console.ReadLine();

                            var updatedCtegory = categoryRepository.Get(updatedCategoryId);

                            categoryRepository.Update(updatedCtegory);
                            Console.WriteLine("Category Güncellendi");
                            break;
                        case "7":
                            Console.Write("Category Id: ");
                            Guid deletedCategoryId = Guid.Parse(Console.ReadLine());

                            categoryRepository.Delete(categoryRepository.Get(deletedCategoryId));
                            Console.WriteLine("Category Silindi");
                            break;
                        case "8":
                            var categories = categoryRepository.GetAll();
                            foreach (var category in categories)
                            {
                                Console.WriteLine(category);
                            }
                            break;
                        case "9":
                            Console.Write("Post Id: ");
                            Guid commentPostId = Guid.Parse(Console.ReadLine());

                            Console.Write("Yorum: ");
                            string comment = Console.ReadLine();

                            var commentPost = postRepository.Get(commentPostId);

                            var newComment = new Comment()
                            {
                                Content = comment,
                                User = currentUser,
                                Post = commentPost

                            };

                            commentRepository.Create(newComment);
                            Console.WriteLine("Comment Oluşturuldu");

                            break;
                        case "10":
                            Console.Write("Comment Id: ");
                            Guid updatedCommentId = Guid.Parse(Console.ReadLine());

                            Console.Write("Yorum: ");
                            string updatedComment = Console.ReadLine();

                            var updatedCommentPost = commentRepository.Get(updatedCommentId);
                            updatedCommentPost.Content = updatedComment;

                            commentRepository.Update(updatedCommentPost);
                            Console.WriteLine("Comment Güncellendi");

                            break;
                        case "11":
                            Console.Write("Comment Id: ");
                            Guid deletedCommentId = Guid.Parse(Console.ReadLine());


                            var deletedCommentPost = commentRepository.Get(deletedCommentId);

                            commentRepository.Delete(deletedCommentPost);
                            Console.WriteLine("Comment Silindi");
                            break;
                        case "12":
                            Console.Write("Post Id: ");
                            Guid getPostId = Guid.Parse(Console.ReadLine());

                            var comments = commentRepository.GetByPostId(getPostId);

                            foreach (var cm in comments)
                            {
                                Console.WriteLine(cm);
                            }

                            break;
                        default:
                            Console.WriteLine("Yanlış Seçim");
                            break;
                    }
                }

            } while (true);
        }
    }
}
