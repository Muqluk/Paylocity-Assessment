# Business Need <sup><sup><sub>[Return to Docs List](/readme.md)<sub></sup></sup>

---

> One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits packages.  A portion of these costs are deducted from their paycheck, and we handle that deduction.

## Please demonstrate how you would code the following scenario:

* The cost of benefits is $1000 / year for each employee
* Each dependent (children and possibly spouses) incurs a cost of $500/year
* Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

### Because this calculation will be needed in multiple[^1] places we will need:
* A well-designed domain API to serve this data in a _scalable_ fashion. 
* Employees may use one **or more** devices to choose their benefits package as part of a multi-step process
* Process steps to include
  1. Manage dependents
      * Add
      * Remove
      * Edit
      * Preview & Confirmation of edits.
  1. Preview of the costs (running total as well as final)
  1. Administrators need to preview & verify numbers before before payroll is ran
* The costs _may change_ in between so the calculation needs to reflect the _current_ state of the calculation, rather than the state at the time the employee entered it.

[^1]: Planned to be consumed via multiple web applications, mobile devices, etc 