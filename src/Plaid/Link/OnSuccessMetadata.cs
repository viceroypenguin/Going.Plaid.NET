﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Going.Plaid.Link
{
	/// <summary>
	/// Provides a data structure to use to deserialize the Plaid JSON metadata returned when the onSuccess event
	/// in the Plaid Link flow is triggered. 
	/// </summary>
	public class OnSuccessMetadata
	{

		/// <summary>
		/// The public_token is passed to the onSuccess Javascript callback as a separate parameter from 
		/// the metadata structure itself. It must be manually added to the metadata in order to be 
		/// included when deserializing.<br/>
		/// <example>
		/// <code>
		///  onSuccess: async function(public_token, metadata)
		///  {
		///	   // The metadata object contains info about the institution the
		///	   // user selected and the account ID or IDs, if the
		///	   // Select Account view is enabled.
		///	   // https://plaid.com/docs/#onsuccess-callback
		///
		///	   metadata.public_token = public_token;
		///	  
		///	   ... send the metadata as JSON to be deserialized into this class ...  
		///	  
		///	  }
		/// </code>
		/// </example>
		/// </summary>
		/// <value>The public token.</value>
		[JsonPropertyName("public_token")]
		public string PublicToken { get; init; } = null!;

		/// <summary>
		/// Gets or sets the link session identifier.
		/// </summary>
		/// <value>The link session identifier.</value>
		[JsonPropertyName("link_session_id")]
		public string LinkSessionId { get; init; } = null!;

		/// <summary>
		/// Gets or sets the link session identifier.
		/// </summary>
		/// <value>The link session identifier.</value>
		[JsonPropertyName("account_id")]
		public string AccountId { get; init; } = null!;

		/// <summary>
		/// Gets or sets the accounts info.
		/// </summary>
		/// <value>The accounts.</value>
		[JsonPropertyName("accounts")]
		public IReadOnlyList<AccountInfo> Accounts { get; init; } = null!;

		/// <summary>
		/// Gets or sets the institution.
		/// </summary>
		/// <value>The institution.</value>
		[JsonPropertyName("institution")]
		public InstitutionInfo Institution { get; init; } = null!;


		/// <summary>
		/// Represents a subset of <see cref="Entity.Account"/> metadata.
		/// </summary>
		/// <remarks>
		/// This is a subset of the <see cref="Entity.Account"/> class. 
		/// It's defined separately because <i>only</i> these properties 
		/// are ever in the JSON metadata for onSuccess, and the 'id' property 
		/// is named differently in the raw metadata.
		/// </remarks>		
		public class AccountInfo
		{
			/// <summary>
			/// Gets or sets the <see cref="Entity.Account"/> identifier.
			/// </summary>
			/// <value>The identifier.</value>
			[JsonPropertyName("id")]
			public string Id { get; init; } = null!;

			/// <summary>
			/// Gets or sets the <see cref="Entity.Account"/> name.
			/// </summary>
			/// <value>The name.</value>
			[JsonPropertyName("name")]
			public string Name { get; init; } = null!;

			/// <summary>
			/// The last 2-4 alphanumeric characters of an account's official account number.
			/// </summary>
			/// <remarks>The mask may be non-unique between an Item's accounts, it may also not match the mask that the bank displays to the user.</remarks>
			[JsonPropertyName("mask")]
			public string Mask { get; init; } = null!;

			/// <summary>
			/// Gets or sets the type.
			/// </summary>
			/// <value>The type.</value>
			[JsonPropertyName("type")]
			public Entity.AccountType? Type { get; init; } = null!;

			/// <summary>
			/// Gets or sets the type of the sub.
			/// </summary>
			/// <value>The type of the sub.</value>
			[JsonPropertyName("subtype")]
			public Entity.AccountSubType? SubType { get; init; } = null!;
		}


		/// <summary>
		/// Represents a subset of the  <see cref="Entity.Institution"/> metadata.
		/// </summary>
		/// <remarks>
		/// This is a subset of the <see cref="Entity.Institution"/> class. 
		/// It's defined separately because <i>only</i> these two properties 
		/// are ever in the JSON metadata for onSuccess
		/// </remarks>
		public class InstitutionInfo
		{
			/// <summary>
			/// Gets or sets the <see cref="Entity.Institution"/> identifier.
			/// </summary>
			/// <value>The identifier.</value>
			[JsonPropertyName("institution_id")]
			public string Id { get; init; } = null!;

			/// <summary>
			/// Gets or sets the <see cref="Entity.Institution"/> name.
			/// </summary>
			/// <value>The name.</value>
			[JsonPropertyName("name")]
			public string Name { get; init; } = null!;
		}
	}
}

