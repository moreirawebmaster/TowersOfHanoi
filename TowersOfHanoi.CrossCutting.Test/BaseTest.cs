using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMoq;
using NUnit.Framework;

namespace TowersOfHanoi.CrossCutting.Test
{
    [TestFixture]
    public class BaseTest
    {
        protected AutoMoqer mocker;

        public BaseTest()
        {
            mocker = new AutoMoqer();
        }

        public void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property, T entity) where T : class
        {
            mocker.GetMock<IDbSet<T>>()
                .SetUpDbSet(new List<T> { entity });

            mocker.GetMock<IDatabaseService>()
                .Setup(property)
                .Returns(mocker.GetMock<IDbSet<T>>().Object);
        }

        public void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property)
            where T : class
        {
            mocker.GetMock<IDbSet<T>>()
                .SetUpDbSet(new List<T>());

            mocker.GetMock<IDatabaseService>()
                .Setup(property)
                .Returns(mocker.GetMock<IDbSet<T>>().Object);
        }
    }
}
