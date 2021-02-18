using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Blog.Models;

namespace Blog.Extensions
{
	public class GetArhiveComparer : IEqualityComparer<GetArhiveViewModel>
	{
		public bool Equals([AllowNull] GetArhiveViewModel x, [AllowNull] GetArhiveViewModel y)
		{
			//Check whether the compared objects reference the same data.
        	if (Object.ReferenceEquals(x, y)) return true;

        	//Check whether any of the compared objects is null.
        	if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        	//Check whether the products' properties are equal.
        	return x.MonthNum == y.MonthNum || x.Year != y.Year;
		}

		public int GetHashCode([DisallowNull] GetArhiveViewModel arhiveVM)
		{
			//Check whether the object is null
        if (Object.ReferenceEquals(arhiveVM, null)) return 0;

        //Get hash code for the Code field.
        int hashArhiveMonth = arhiveVM.MonthNum.GetHashCode();
		int hashArhiveYear = arhiveVM.Year.GetHashCode();
        //Calculate the hash code for the product.
        return hashArhiveMonth ^ hashArhiveYear;
		}
	}
}