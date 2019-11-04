﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TmsFrontend
{
    /// <summary>
    /// Interaction logic for StudentTestsMain.xaml
    /// </summary>
    public partial class StudentTestsMain : Page
    {
        List<TestPreview> TestPreviews = new List<TestPreview> { };
        List<TestPreview> TestsDisplayed = new List<TestPreview> { };
        private int StudentKey;

        public StudentTestsMain(int studentId)
        {
            InitializeComponent();
            StudentKey = studentId;

            setButtons();
            setTests();

            changeTextBlocks(TestsDisplayed[0].Title as string);
        }

        public void setTests()
        {
            
            TestPreviews.Add(new TestPreview()
            {
                Questions = "5",
                TimeLimit = "50 Minutes",
                SetBy = "Graham Nolan",
                Topic = "C#",
                Title = "C# Practical Programming Test",
                Assigned = new int[1] { 2 }
            });

            TestPreviews.Add(new TestPreview()
            {
                Questions = "5",
                TimeLimit = "50 Minutes",
                SetBy = "Graham Nolan",
                Topic = "WPF",
                Title = "WPF Test",
                Assigned = new int[1] { 1 }
            });

            assignResults();
        }

        public void assignResults()
        {
            foreach (var item in TestPreviews)
            {
                foreach (var num in item.Assigned)
                {
                    if (num == StudentKey)
                    {
                        TestsDisplayed.Add(item);
                    }
                }
            }
        }

        public void setButtons()
        {
            ResultsList.ItemsSource = TestsDisplayed;
        }

        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            Window win2 = new Window();
            win2.Show();
        }

        private void ChangeTest(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;

            changeTextBlocks(buttonHolder.Content as string);
        }

        private void changeTextBlocks(string selectedTest)
        {
            foreach (var item in TestPreviews)
            {
                if (item.Title == selectedTest)
                {
                    TitleBox.Text = item.Title;
                    TitleBox.FontWeight = FontWeights.ExtraBold;

                    QuestionsBox.Text = "Questions: ";
                    QuestionsBox.FontWeight = FontWeights.Bold;
                    QuestionsBox.Inlines.Add(new Run(item.Questions) { FontWeight = FontWeights.Normal });

                    TimeLimitBox.Text = "Time Limit: ";
                    TimeLimitBox.FontWeight = FontWeights.Bold;
                    TimeLimitBox.Inlines.Add(new Run(item.TimeLimit) { FontWeight = FontWeights.Normal });

                    SetByBox.Text = "Set By: ";
                    SetByBox.FontWeight = FontWeights.Bold;
                    SetByBox.Inlines.Add(new Run(item.SetBy) { FontWeight = FontWeights.Normal });

                    TopicBox.Text = "Topic: ";
                    TopicBox.FontWeight = FontWeights.Bold;
                    TopicBox.Inlines.Add(new Run(item.Topic) { FontWeight = FontWeights.Normal });
                }
            }
        }

        private void TestInDepth(object sender, RoutedEventArgs e)
        {
            InsideTest insideTest = new InsideTest();
            insideTest.Show();
        }
    }

    public class TestPreview
    {
        public string Title { get; set; }
        public string Questions { get; set; }
        public string TimeLimit { get; set; }
        public string SetBy { get; set; }
        public string Topic { get; set; }
        public int[] Assigned { get; set; }
    }
}
