using System;
using System.Collections.Generic;

namespace TestDataService.Models.Entities
{
    public partial class VisionAndScopeDocs
    {
        public int ProjectId { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public string ChangeName { get; set; }
        public string ChangeReason { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string BusinessRequirements { get; set; }
        public string Background { get; set; }
        public string BusinessOpportunity { get; set; }
        public string BusinessObjectives { get; set; }
        public string SuccessMetrics { get; set; }
        public string VisionStatements { get; set; }
        public string BusinessRisks { get; set; }
        public string BusinessAssumptionsAndDependencies { get; set; }
        public string ScopeAndLimitations { get; set; }
        public string MajorFeatures { get; set; }
        public string ScopeOfInitialRelease { get; set; }
        public string ScopeOfSubsequentReleases { get; set; }
        public string LimitationsAndExclusions { get; set; }
        public string BusinessContext { get; set; }
        public string StakeHolderProfiles { get; set; }
        public string ProjectPriorities { get; set; }
        public string DeploymentConsiderations { get; set; }

        public virtual Projects Project { get; set; }
    }
}
