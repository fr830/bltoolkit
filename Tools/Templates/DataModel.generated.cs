﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by BLToolkit template for T4.
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

using BLToolkit.Common;
using BLToolkit.Data;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Templates
{
	public partial class DataModel : DbManager
	{
		public Table<BinaryData>    BinaryData    { get { return GetTable<BinaryData>();    } }
		public Table<Child>         Child         { get { return GetTable<Child>();         } }
		public Table<DataTypeTest>  DataTypeTest  { get { return GetTable<DataTypeTest>();  } }
		public Table<Doctor>        Doctor        { get { return GetTable<Doctor>();        } }
		public Table<GrandChild>    GrandChild    { get { return GetTable<GrandChild>();    } }
		public Table<LinqDataTypes> LinqDataTypes { get { return GetTable<LinqDataTypes>(); } }
		public Table<MyTable>       MyTable       { get { return GetTable<MyTable>();       } }
		public Table<Parent>        Parent        { get { return GetTable<Parent>();        } }
		public Table<Patient>       Patient       { get { return GetTable<Patient>();       } }
		public Table<Person>        Person        { get { return GetTable<Person>();        } }
	}

	[Serializable, DataContract]
	[TableName(Name="BinaryData")]
	public partial class BinaryData : EntityBase<BinaryData>
	{
		[MapField("BinaryDataID"), Identity, PrimaryKey(1), DataMember] public int    ID    { get; set; }
		[                                                   DataMember] public byte[] Stamp { get; set; }
		[                                                   DataMember] public byte[] Data  { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="Child")]
	public partial class Child : EntityBase<Child>
	{
		[DataMember] public int ParentID { get; set; }
		[DataMember] public int ChildID  { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="DataTypeTest")]
	public partial class DataTypeTest : EntityBase<DataTypeTest>
	{
		[Identity, PrimaryKey(1), DataMember] public int       DataTypeID { get; set; }
		[Nullable,                DataMember] public byte[]    Binary_    { get; set; }
		[                         DataMember] public bool      Boolean_   { get; set; }
		[Nullable,                DataMember] public byte?     Byte_      { get; set; }
		[Nullable,                DataMember] public byte[]    Bytes_     { get; set; }
		[Nullable,                DataMember] public char?     Char_      { get; set; }
		[Nullable,                DataMember] public DateTime? DateTime_  { get; set; }
		[Nullable,                DataMember] public decimal?  Decimal_   { get; set; }
		[Nullable,                DataMember] public double?   Double_    { get; set; }
		[Nullable,                DataMember] public byte[]    Guid_      { get; set; }
		[Nullable,                DataMember] public short?    Int16_     { get; set; }
		[Nullable,                DataMember] public int?      Int32_     { get; set; }
		[Nullable,                DataMember] public long?     Int64_     { get; set; }
		[Nullable,                DataMember] public decimal?  Money_     { get; set; }
		[Nullable,                DataMember] public byte?     SByte_     { get; set; }
		[Nullable,                DataMember] public float?    Single_    { get; set; }
		[Nullable,                DataMember] public byte[]    Stream_    { get; set; }
		[Nullable,                DataMember] public string    String_    { get; set; }
		[Nullable,                DataMember] public short?    UInt16_    { get; set; }
		[Nullable,                DataMember] public int?      UInt32_    { get; set; }
		[Nullable,                DataMember] public long?     UInt64_    { get; set; }
		[Nullable,                DataMember] public string    Xml_       { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="Doctor")]
	public partial class Doctor : EntityBase<Doctor>
	{
		[PrimaryKey(1), DataMember] public int    PersonID { get; set; }
		[               DataMember] public string Taxonomy { get; set; }

		// FK_Doctor_Person
		[Association(ThisKey="PersonID", OtherKey="ID")]
		public Person Person { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="GrandChild")]
	public partial class GrandChild : EntityBase<GrandChild>
	{
		[DataMember] public int ParentID     { get; set; }
		[DataMember] public int ChildID      { get; set; }
		[DataMember] public int GrandChildID { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="LinqDataTypes")]
	public partial class LinqDataTypes : EntityBase<LinqDataTypes>
	{
		[          DataMember] public int      ID            { get; set; }
		[          DataMember] public decimal  MoneyValue    { get; set; }
		[          DataMember] public DateTime DateTimeValue { get; set; }
		[          DataMember] public bool     BoolValue     { get; set; }
		[          DataMember] public string   GuidValue     { get; set; }
		[Nullable, DataMember] public byte[]   BinaryValue   { get; set; }
		[          DataMember] public short    SmallIntValue { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="MyTable")]
	public partial class MyTable : EntityBase<MyTable>
	{
		[Nullable, DataMember] public int? MyID { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="Parent")]
	public partial class Parent : EntityBase<Parent>
	{
		[          DataMember] public int  ParentID { get; set; }
		[Nullable, DataMember] public int? Value1   { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="Patient")]
	public partial class Patient : EntityBase<Patient>
	{
		[PrimaryKey(1), DataMember] public int    PersonID  { get; set; }
		[               DataMember] public string Diagnosis { get; set; }

		// FK_Patient_Person
		[Association(ThisKey="PersonID", OtherKey="ID")]
		public Person Person { get; set; }
	}

	[Serializable, DataContract]
	[TableName(Name="Person")]
	public partial class Person : EntityBase<Person>
	{
		[MapField("PersonID"), Identity, PrimaryKey(1), DataMember] public int    ID         { get; set; }
		[                                               DataMember] public string FirstName  { get; set; }
		[                                               DataMember] public string LastName   { get; set; }
		[                      Nullable,                DataMember] public string MiddleName { get; set; }
		[                                               DataMember] public char   Gender     { get; set; }

		// FK_Doctor_Person_BackReference
		[Association(ThisKey="ID", OtherKey="PersonID")]
		public Doctor Doctor { get; set; }

		// FK_Patient_Person_BackReference
		[Association(ThisKey="ID", OtherKey="PersonID")]
		public Patient Patient { get; set; }
	}
}