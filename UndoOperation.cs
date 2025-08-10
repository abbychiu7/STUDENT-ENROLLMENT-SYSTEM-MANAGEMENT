using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    //==============================//
    //       UNDO OPERATION ADT     //
    //==============================//
    // Stores the undo action details (description and actual action to run).
    // This is used to implement the undo functionality in the enrollment system.
    public class UndoOperation
    {
        public string Description;
        public Action Operation;

        public UndoOperation(string description, Action operation)
        {
            Description = description;
            Operation = operation;
        }
    }
}
