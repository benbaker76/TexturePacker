using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace TexturePacker
{
	public class StringTools
	{
		private static CultureInfo m_enUSCultureInfo = null;

		static StringTools()
		{
			m_enUSCultureInfo = CultureInfo.CreateSpecificCulture("en-US");
		}

		public static bool TryParseBool(string valueString, out bool valueBool)
		{
			valueBool = false;

			if (String.Compare(valueString, "yes", true) == 0)
			{
				valueBool = true;

				return true;
			}
			else if (String.Compare(valueString, "no", true) == 0)
			{
				valueBool = false;

				return true;
			}
			else if (String.Compare(valueString, "1", true) == 0)
			{
				valueBool = true;

				return true;
			}
			else if (String.Compare(valueString, "0", true) == 0)
			{
				valueBool = false;

				return true;
			}

			return bool.TryParse(valueString, out valueBool);
		}

		public static bool TryConvertToString<T>(T value, out string valueString)
		{
			return TryConvertToString(typeof(T), value, out valueString);
		}

		public static bool TryConvertToString(Type objectType, object valueObject, out string valueString)
		{
			valueString = null;

			if (valueObject == null)
				return false;

			if (objectType == typeof(string))
			{
				valueString = (string)valueObject;

				return true;
			}

			try
			{
				TypeConverter typeConverter = TypeDescriptor.GetConverter(objectType);
				valueString = typeConverter.ConvertToString(null, m_enUSCultureInfo, valueObject);
			}
			catch
			{
				return false;
			}

			return true;
		}

		public static bool TryConvertFromString<T>(string valueString, out T value)
		{
			value = default(T);
			object valueObject = null;

			if (!TryConvertFromString(typeof(T), valueString, out valueObject))
				return false;

			value = (T)valueObject;

			return true;
		}

		public static bool TryConvertFromString(Type objectType, string valueString, out object valueObject)
		{
			valueObject = null;

			if (valueString == null)
				return false;

			if (objectType == typeof(string))
			{
				valueObject = valueString;

				return true;
			}
			else if (objectType == typeof(int))
			{
				int valueInt;

				if (int.TryParse(valueString, out valueInt))
				{
					valueObject = valueInt;

					return true;
				}
				else
					return false;
			}
			else if (objectType == typeof(uint))
			{
				uint valueInt;

				if (uint.TryParse(valueString, out valueInt))
				{
					valueObject = valueInt;

					return true;
				}
				else
					return false;
			}
			else if (objectType == typeof(long))
			{
				long valueLong;

				if (long.TryParse(valueString, out valueLong))
				{
					valueObject = valueLong;

					return true;
				}
				else
					return false;
			}
			else if (objectType == typeof(ulong))
			{
				ulong valueLong;

				if (ulong.TryParse(valueString, out valueLong))
				{
					valueObject = valueLong;

					return true;
				}
				else
					return false;
			}
			else if (objectType == typeof(float))
			{
				float valueFloat;

				if (float.TryParse(valueString, NumberStyles.Any, m_enUSCultureInfo, out valueFloat))
				{
					valueObject = valueFloat;

					return true;
				}
				else
					return false;
			}
			else if (objectType == typeof(double))
			{
				double valueDouble;

				if (double.TryParse(valueString, NumberStyles.Any, m_enUSCultureInfo, out valueDouble))
				{
					valueObject = valueDouble;

					return true;
				}
				else
					return false;
			}
			else if (objectType == typeof(bool))
			{
				bool valueBool;

				if (TryParseBool(valueString, out valueBool))
				{
					valueObject = valueBool;

					return true;
				}
				else
					return false;
			}

			try
			{
				TypeConverter typeConverter = TypeDescriptor.GetConverter(objectType);
				valueObject = typeConverter.ConvertFromString(null, m_enUSCultureInfo, valueString);
			}
			catch
			{
				return false;
			}

			return true;
		}

		public static T FromString<T>(string valueString)
		{
			T value;

			TryConvertFromString(valueString, out value);

			return value;
		}

		public static T FromString<T>(string valueString, T defaultValue)
		{
			T value;

			if (!TryConvertFromString(valueString, out value))
				return defaultValue;

			return value;
		}

		public static string ToString<T>(T value)
		{
			string valueString = null;

			TryConvertToString(value, out valueString);

			return valueString;
		}

		public static string ArrayToString<T>(T[] valueArray, string delimeter)
		{
			if (valueArray == null)
				return null;

			string[] stringArray = new string[valueArray.Length];

			for (int i = 0; i < valueArray.Length; i++)
				TryConvertToString(valueArray[i], out stringArray[i]);

			return String.Join(delimeter, stringArray);
		}

		public static T[] StringToArray<T>(string valueString, string delimeter)
		{
			string[] dataArray = valueString.Split(new char[] { '~' });
			T[] valueArray = new T[dataArray.Length];
			TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));

			for (int i = 0; i < valueArray.Length; i++)
				TryConvertFromString(dataArray[i], out valueArray[i]);

			return valueArray;
		}

		public static T[] Array<T>(T value, int count)
		{
			T[] result = new T[count];
			for (int i = 0; i < count; i++)
				result[i] = value;

			return result;
		}
	}
}
