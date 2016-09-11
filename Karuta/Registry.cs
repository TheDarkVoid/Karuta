using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace com.LuminousVector.DataStore
{
	[ProtoContract]
	public class Registry
	{
		[ProtoMember(1)]
		private Dictionary<string, string> stringStore;
		[ProtoMember(2)]
		private Dictionary<string, int> intStore;
		[ProtoMember(3)]
		private Dictionary<string, bool> boolStore;
		[ProtoMember(4)]
		private Dictionary<string, float> floatStore;

		public Registry() { }

		public void Init()
		{
			stringStore = new Dictionary<string, string>();
			intStore = new Dictionary<string, int>();
			boolStore = new Dictionary<string, bool>();
			floatStore = new Dictionary<string, float>();
		}

		public string GetString(string id)
		{
			string value;
			if (stringStore == null)
				return null;
			stringStore.TryGetValue(id, out value);
			if (value == null)
				value = "";
			return value;
		}

		public int? GetInt(string id)
		{
			int value;
			if (intStore == null)
				return null;
			if (!intStore.TryGetValue(id, out value))
				return null;
			else
				return value;
		}

		public bool? GetBool(string id)
		{
			bool value;
			if (boolStore == null)
				return null;
			if (!boolStore.TryGetValue(id, out value))
				return null;
			else
				return value;
		}

		public float? GetFloat(string id)
		{
			float value;
			if (floatStore == null)
				return null;
			floatStore.TryGetValue(id, out value);
			return value;
		}

		public void SetValue(string id, string value)
		{
			if (stringStore == null)
				stringStore = new Dictionary<string, string>();
			if (stringStore.ContainsKey(id))
				stringStore[id] = value;
			else
				stringStore.Add(id, value);
		}

		public void SetValue(string id, int value)
		{
			if (intStore == null)
				intStore = new Dictionary<string, int>();
			if (intStore.ContainsKey(id))
				intStore[id] = value;
			else
				intStore.Add(id, value);
		}

		public void SetValue(string id, bool value)
		{
			if (boolStore == null)
				boolStore = new Dictionary<string, bool>();
			if (boolStore.ContainsKey(id))
				boolStore[id] = value;
			else
				boolStore.Add(id, value);
		}

		public void SetValue(string id, float value)
		{
			if (floatStore == null)
				floatStore = new Dictionary<string, float>();
			if (floatStore.ContainsKey(id))
				floatStore[id] = value;
			else
				floatStore.Add(id, value);
		}

		public void RemoveEntry<T>(string id)
		{
			if (typeof(T) == typeof(string))
			{
				stringStore.Remove(id);
			}
			else if (typeof(T) == typeof(int))
			{
				intStore.Remove(id);
			}
			else if (typeof(T) == typeof(bool))
			{
				boolStore.Remove(id);
			}
			else if (typeof(T) == typeof(float))
			{
				floatStore.Remove(id);
			}
		}
	}
}
