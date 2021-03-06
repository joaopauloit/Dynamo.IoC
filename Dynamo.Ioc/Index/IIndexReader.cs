﻿using System;
using System.Collections.Generic;

// Should TryGetAll use normal TryXxx pattern with out parameter ? - in that case it cant use yield return and be lazy
// Implement IsEmpty and Count or just use Linq Count() and Any() for that ? - implementing it will of course result in better performance

// No reason for the Generic overloads - they are just syntactic suger.
	// Remove them or put move to be extension methods, to make the interface lighter?
	// But if generic methods is used (as extension methods), it is anoying that you have to remember to declare the using every place used.

namespace Dynamo.Ioc.Index
{
	public interface IIndexReader : IEnumerable<IRegistration>
	{
		IRegistration Get(Type type);
		IRegistration Get(Type type, object key);
		IRegistration Get<T>();
		IRegistration Get<T>(object key);

		bool TryGet(Type type, out IRegistration registration);
		bool TryGet(Type type, object key, out IRegistration registration);
		bool TryGet<T>(out IRegistration registration);
		bool TryGet<T>(object key, out IRegistration registration);

		IEnumerable<IRegistration> GetAll(Type type);
		IEnumerable<IRegistration> GetAll<T>();

		IEnumerable<IRegistration> TryGetAll(Type type);
		IEnumerable<IRegistration> TryGetAll<T>();
		
		// Better names - that make the difference between Contains and ContainsAny more clear ?
		bool Contains(Type type);
		bool Contains(Type type, object key);
		bool Contains<T>();
		bool Contains<T>(object key);
		
		bool ContainsAny(Type type);
		bool ContainsAny<T>();
	}
}