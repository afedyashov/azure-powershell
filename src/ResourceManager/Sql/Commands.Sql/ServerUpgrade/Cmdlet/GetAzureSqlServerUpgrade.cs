﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Azure.Commands.Sql.ServerUpgrade.Model;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.ServerUpgrade.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServerUpgrade cmdlet
    /// </summary>
    [CmdletDeprecation(ChangeDescription = "All Azure SQL DB Servers now have version 12.0 so there is nothing to upgrade.")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerUpgrade", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlServerUpgradeModel))]
    public class GetAzureSqlServerUpgrade : AzureSqlServerUpgradeCmdletBase<AzureSqlServerUpgradeModel>
    {
        /// <summary>
        /// Gets a server upgrade from the service.
        /// </summary>
        /// <returns>A single server upgrade</returns>
        protected override IEnumerable<AzureSqlServerUpgradeModel> GetEntity()
        {
            return new List<AzureSqlServerUpgradeModel>()
            {
                ModelAdapter.GetUpgrade(this.ResourceGroupName, this.ServerName)
            };
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="models">The models to modify</param>
        /// <returns>The input models</returns>
        protected override IEnumerable<AzureSqlServerUpgradeModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerUpgradeModel> models)
        {
            return models;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerUpgradeModel> PersistChanges(IEnumerable<AzureSqlServerUpgradeModel> entity)
        {
            return entity;
        }
    }
}
