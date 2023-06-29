﻿using MVCExamProject.Data;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Repository
{
    public class QuestionOptionService : IQuestionOptionRepository
    {
        private readonly ExamContext context;

        public QuestionOptionService(ExamContext context)
        {
            this.context = context;
        }
        public void Delete(QuestionOption t)
        {
            context.QuestionOptions.Remove(t);
        }

        public List<QuestionOption> GetAll()
        {
            return context.QuestionOptions.ToList();
        }

        public QuestionOption GetById(int id)
        {
            return context.QuestionOptions.FirstOrDefault(q => q.Id == id);
        }

        public void Insert(QuestionOption t)
        {
            context.QuestionOptions.Add(t);
        }

        public void Update(QuestionOption t)
        {
            context.QuestionOptions.Update(t);
        }

        public List<QuestionOption> getForQuestionsList(List<ExamQuestion> questions)
        {
            var options = new List<QuestionOption>();
            foreach (ExamQuestion question in questions)
            {
                QuestionOption option = context.QuestionOptions.Where(o => o.ExamQuestionId == question.Id).FirstOrDefault();
                options.Add(option);
            }

            return options;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
