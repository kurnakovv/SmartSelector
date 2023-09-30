using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartSelector
{
    internal class SelectorGenericExtensions<TSource>
    {
        private static readonly ConcurrentDictionary<string, ParameterExpression> _parameters = new ConcurrentDictionary<string, ParameterExpression>();
        private static readonly ConcurrentDictionary<string, MemberAssignment> _members = new ConcurrentDictionary<string, MemberAssignment>();
        private static readonly ConcurrentDictionary<string, Expression<Func<TSource, TSource>>> _selectors = new ConcurrentDictionary<string, Expression<Func<TSource, TSource>>>();

        public static IQueryable<TSource> SelectFields(IQueryable<TSource> source, IEnumerable<string> fieldNames)
        {
            string parameterName = typeof(TSource).FullName;
            string requestName = $"{parameterName}:{string.Join(",", fieldNames.OrderBy(x => x))}";
            if (_selectors.TryGetValue(requestName, out Expression<Func<TSource, TSource>> selector))
            {
                return source.Select(selector);
            }
            if (!_parameters.TryGetValue(parameterName, out ParameterExpression parameter))
            {
                parameter = Expression.Parameter(typeof(TSource), typeof(TSource).Name.ToLowerInvariant());
                _parameters.TryAdd(parameterName, parameter);
            }
            IEnumerable<MemberAssignment> members = fieldNames
                .Select(name =>
                {
                    string memberName = $"{parameterName}:{name}";
                    if (!_members.TryGetValue(memberName, out MemberAssignment member))
                    {
                        MemberExpression expression = Expression.PropertyOrField(parameter, name);
                        member = Expression.Bind(expression.Member, expression);
                        _members.TryAdd(memberName, member);
                    }
                    return member;
                });
            MemberInitExpression body = Expression.MemberInit(Expression.New(typeof(TSource)), members);
            selector = Expression.Lambda<Func<TSource, TSource>>(body, parameter);
            _selectors.TryAdd(requestName, selector);
            return source.Select(selector);
        }
    }
}
