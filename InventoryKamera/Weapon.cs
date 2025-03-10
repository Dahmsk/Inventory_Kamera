﻿using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace InventoryKamera
{
	public class Weapon
	{
		[JsonProperty("key")]
		public string Name { get; private set; }

		[JsonProperty("level")]
		public int Level { get; private set; }

		[JsonProperty("ascension")]
		public int AscensionLevel { get { return AscensionCount(); } private set { } }

		[JsonProperty("refinement")]
		public int RefinementLevel { get; private set; }

		[JsonProperty("location")]
		[DefaultValue("")]
		public string EquippedCharacter { get; private set; }

		[JsonProperty("lock")]
		public bool Lock { get; private set; }

		[JsonIgnore]
		public int Rarity { get; private set; }

		[JsonIgnore]
		public bool Ascended { get; private set; }

		[JsonIgnore]
		public int Id { get; private set; }

		[JsonIgnore]
		public WeaponType WeaponType { get; private set; }

		public Weapon()
		{
			RefinementLevel = -1;
			Id = -1;
			Rarity = -1;
		}

		public Weapon(WeaponType _weaponType, string _equippedCharacter)
		{
			WeaponType = _weaponType;
			Level = 1;
			Rarity = 1;
			RefinementLevel = 1;
			EquippedCharacter = _equippedCharacter;

			switch (WeaponType)
			{
				case WeaponType.Sword:
					Name = "DullBlade";
					break;
				case WeaponType.Claymore:
					Name = "WasterGreatsword";
					break;
				case WeaponType.Polearm:
					Name = "BeginnersProtector";
					break;
				case WeaponType.Bow:
					Name = "HuntersBow";
					break;
				case WeaponType.Catalyst:
					Name = "ApprenticesNotes";
					break;
				default:
					throw new ArgumentException($"{_weaponType} is an invalid weapon type");
			}
		}

		public Weapon(string _name, int _level, bool _ascended, int _refinementLevel, string _equippedCharacter = null, int _id = 0, int _rarity = -1)
		{
			Name = _name;
			Level = _level;
			Ascended = _ascended;
			RefinementLevel = _refinementLevel;
			EquippedCharacter = string.IsNullOrWhiteSpace(_equippedCharacter) ? "" : _equippedCharacter;
			Id = _id;
			Rarity = _rarity;
		}

		public bool IsValid()
		{
			return 1 <= Level
				&& Level <= 90
				&& 0 <= RefinementLevel
				&& RefinementLevel <= 5
				&& Scraper.IsValidWeapon(Name)
				&& (string.IsNullOrWhiteSpace(EquippedCharacter) || Scraper.IsValidCharacter(EquippedCharacter));
		}

		public int AscensionCount()
		{
			if (Level < 20 || ( Level == 20 && Ascended == false ))
			{
				return 0;
			}
			else if (Level < 40 || ( Level == 40 && Ascended == false ))
			{
				return 1;
			}
			else if (Level < 50 || ( Level == 50 && Ascended == false ))
			{
				return 2;
			}
			else if (Level < 60 || ( Level == 60 && Ascended == false ))
			{
				return 3;
			}
			else if (Level < 70 || ( Level == 70 && Ascended == false ))
			{
				return 4;
			}
			else if (Level < 80 || ( Level == 80 && Ascended == false ))
			{
				return 5;
			}
			else if (Level <= 90 || ( Level == 90 && Ascended == false ))
			{
				return 6;
			}
			return 0;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj as Weapon);
		}

		public bool Equals(Weapon weapon)
		{
			if (weapon is null)
			{
				return false;
			}

			if (Object.ReferenceEquals(this, weapon))
			{
				return true;
			}

			if (GetType() != weapon.GetType())
			{
				return false;
			}

			return Name == weapon.Name && Level == weapon.Level && Ascended == weapon.Ascended && RefinementLevel == weapon.RefinementLevel;
		}

		public override int GetHashCode() => (Name, Level, Ascended, RefinementLevel, EquippedCharacter).GetHashCode();

		public static bool operator ==(Weapon lhs, Weapon rhs)
		{
			if (lhs is null)
			{
				if (rhs is null)
				{
					return true;
				}
				return false;
			}

			return lhs.Equals(rhs);
		}

		public static bool operator !=(Weapon lhs, Weapon rhs) => !( lhs == rhs );
	}

	public enum WeaponType
	{
		Sword,
		Claymore,
		Polearm,
		Bow,
		Catalyst
	}
}