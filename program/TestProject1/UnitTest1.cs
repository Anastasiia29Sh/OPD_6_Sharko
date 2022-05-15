using NUnit.Framework;
using program;
using System;
using System.Linq;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // �������� �� ���������
        [Test]
        public void TestAdd()
        {
            using (ApplicationContext app = new ApplicationContext())
            {
                app.Books.Add(new Book() { Name = "̸����� ����", Author = "������" });
                app.SaveChanges();
                //��� ���������� ����� �������� ������, �������� ��������� �������
                //���� �� �����������, �������� ������� �� ���������
                Book? book = app.Books.OrderBy(x => x.Id).LastOrDefault();
                Assert.AreEqual(book.Name, "̸����� ����");
                Assert.AreEqual(book.Author, "������");
            }
        }

        [Test]
        public void TestRemove()
        {
            using (ApplicationContext app = new ApplicationContext())
            {
                Book? book = app.Books.OrderBy(x => x.Id).LastOrDefault();
                int count1 = app.Books.Count();
                app.Books.Remove(book);
                app.SaveChanges();
                int count2 = app.Books.Count();
                Assert.IsTrue(count1 == count2 + 1);
            }
        }

        [Test]
        public void TestUpdate()
        {
            using (ApplicationContext app = new ApplicationContext())
            {
                Book? book = app.Books.FirstOrDefault();
                book.Name = "���� �����-������";
                book.Author = "����";
                app.Books.Update(book);
                app.SaveChanges();
                Assert.IsTrue(book.Name == "���� �����-������");
                Assert.IsTrue(book.Author == "����");
            }
        }



    }
}