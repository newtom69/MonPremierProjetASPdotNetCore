﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using MonPremierProjetASPdotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MonPremierProjetASPdotNetCore.DAL
{
    class ArticleDAL
    {
        public Article Details(int id)
        {
           
            using (FoodtrucklyonDbContext db = new FoodtrucklyonDbContext())
            {
                Article larticle;
                var query = (from article in db.Article
                            where article.Id == id
                            select article);
#if DEBUG
                string sql = query.ToSql();
#endif

                larticle = query.FirstOrDefault();
                return larticle;
            }
        }
        internal Article Details(string nom)
        {
            Article larticle;
            using (FoodtrucklyonDbContext db = new FoodtrucklyonDbContext())
            {
                larticle = (from article in db.Article
                            where article.Nom == nom
                            select article).FirstOrDefault();
            }
            return larticle;
        }
        public void AugmenterQuantiteVendue(int id, int nbre)
        {
            using (FoodtrucklyonDbContext db = new FoodtrucklyonDbContext())
            {
                Article larticle = (from article in db.Article
                                    where article.Id == id
                                    select article).FirstOrDefault();
                larticle.NombreVendus += nbre;
                db.SaveChanges();
            }
        }
        internal void AjouterArticleEnBase(Article lArticle)
        {
            using (FoodtrucklyonDbContext db = new FoodtrucklyonDbContext())
            {
                db.Article.Add(lArticle);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    string messageErreur = DALExceptions.HandleException(ex);
                    throw new Exception(messageErreur);
                }
            }
        }
        internal void ReferencerArticle(int id)
        {
            using (FoodtrucklyonDbContext db = new FoodtrucklyonDbContext())
            {
                Article larticle = (from article in db.Article
                                    where article.Id == id
                                    select article).FirstOrDefault();
                larticle.DansCarte = true;
                db.SaveChanges();
            }
        }
        internal void DereferencerArticle(int id)
        {
            using (FoodtrucklyonDbContext db = new FoodtrucklyonDbContext())
            {
                Article larticle = (from article in db.Article
                                    where article.Id == id
                                    select article).FirstOrDefault();
                larticle.DansCarte = false;
                db.SaveChanges();
            }
        }
    }


    public static class IQueryableExtensions //TODEBUG ONLY
    {
#if DEBUG
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Microsoft.EntityFrameworkCore.Storage.Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
            var modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
            var queryModel = modelGenerator.ParseQuery(query.Expression);
            var database = (IDatabase)DataBaseField.GetValue(queryCompiler);
            var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
            var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
#endif
    }
}