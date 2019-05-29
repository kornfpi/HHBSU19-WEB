using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitatWebApp.Models;

namespace HabitatWebApp.Data
{
    public static class DBInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            #region Setup
            context.Database.EnsureCreated();

            // existence of any issues indicates seeding has occurred
            if(context.Issues.Any())
            {
                return;
            }

            #endregion

            #region Issue Diagnosis

            #region Issue

            // seed sample issue data
            var issues = new Issue[]
            {
                new Issue {IssueID=1, Title="Leaking faucet.", Category=Category.Plumbing, Location=Location.Bathroom, Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sed erat at neque tempor blandit at ac enim. Sed eget."},
                new Issue {IssueID=2, Title="Burnt-out Lightbulb.", Category=Category.General, Location=Location.Bedroom, Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sed erat at neque tempor blandit at ac enim. Sed eget."},
                new Issue {IssueID=3, Title="No AC.", Category=Category.HVAC, Location=Location.Bathroom, Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sed erat at neque tempor blandit at ac enim. Sed eget."},
                new Issue {IssueID=4, Title="Gas Smell.", Category=Category.General, Location=Location.Bathroom, Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sed erat at neque tempor blandit at ac enim. Sed eget."},
                new Issue {IssueID=5, Title="Outlet not working.", Category=Category.General, Location=Location.Bathroom, Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sed erat at neque tempor blandit at ac enim. Sed eget."}
            };

            foreach (Issue s in issues)
            {
                context.Issues.Add(s);
            }

            #endregion

            #region PartSystem

            //seed sample part system data
            var partSystems = new PartSystem[]
            {
                new PartSystem {PartSystemID=1, Name="Kitchen Sink", Description="Lorem ipsum dolor sit amet consectetuer adipiscing elit."},
                new PartSystem {PartSystemID=2, Name="Bathroom Toilet", Description="Lorem ipsum dolor sit amet consectetuer adipiscing elit."},
                new PartSystem {PartSystemID=3, Name="Air Conditioning", Description="Lorem ipsum dolor sit amet consectetuer adipiscing elit."},
                new PartSystem {PartSystemID=4, Name="Furnace", Description="Lorem ipsum dolor sit amet consectetuer adipiscing elit."},
                new PartSystem {PartSystemID=5, Name="House Drainage", Description="Lorem ipsum dolor sit amet consectetuer adipiscing elit."}
            };

            foreach (PartSystem p in partSystems)
            {
                context.PartSystems.Add(p);
            }

            #endregion

            #region IssuePartSystem

            // create many-to-many relationships to model
            var issuePartSystems = new IssuePartSystem[]
            {
                new IssuePartSystem {IssueID=3, PartSystemID=3},
                new IssuePartSystem {IssueID=1, PartSystemID=1}
            };

            foreach (IssuePartSystem ips in issuePartSystems)
            {
                context.IssuePartSystems.Add(ips);
            }

            #endregion

            #region Part

            // seed sample Part data
            var parts = new Part[]
            {

            };

            foreach (Part x in parts)
            {
                context.Parts.Add(x);
            }

            #endregion

            #region Symptom

            // seed sample symptom data
            var symptoms = new Symptom[]
            {

            };

            foreach (Symptom sym in symptoms)
            {
                context.Symptoms.Add(sym);
            }

            #endregion

            #endregion

            #region Maintenance Reminders

            var maintenanceItems = new MaintenanceItem[]
            {
                new MaintenanceItem {MaintenanceItemID=1, Name="Check smoke detector batteries", RecurrencePeriod=30},
                new MaintenanceItem {MaintenanceItemID=2, Name="Replace Air Filter", RecurrencePeriod=30},
                new MaintenanceItem {MaintenanceItemID=3, Name="Clean out gutters", RecurrencePeriod=60}
            };

            foreach (MaintenanceItem item in maintenanceItems)
            {
                context.MaintenanceItems.Add(item);
            }

            #endregion
        }
    }
}
