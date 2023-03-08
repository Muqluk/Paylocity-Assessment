# Paylocity Coding Assessment

### Docs Directory
* Original [Assessment Overview](docs/original-requirements-text.md) Text (from emailed word doc)
* Assessment [Objective & Guidelines](docs/assessment-overview.md)
* [Business Need](docs/assessment-overview.md)
* [Assessment Overview](docs/assessment-overview.md)

## Requirements Overview


<details>
  <summary>Business Need</summary>

  <br>
  One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits packages.  A portion of these costs are deducted from their paycheck, and we handle that deduction.
  
  <br />
  <br />
  
  <u>**Please demonstrate how you would code the following scenario:**</u>
  
  * The cost of benefits is $1000 / year for each employee
  * Each dependent (children and possibly spouses) incurs a cost of $500/year
  * Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

  Because this calculation will be needed in multiple places, eg: _multiple_ web applications, mobile devices, etc we will need:
  * A well-designed domain API to serve this data in a _scalable_ fashion. 
  * Employees may use one **or more** devices to choose their benefits package as part of a multi-step process that involves:
    1. managing dependents
    1. need a preview of the costs
    1. administrators need to preview payroll before it is run to double check the numbers.  
  * The **_costs may change in between_**, so the calculation needs to reflect the _current_ state of the calculation, rather than the state at the time the employee entered it.

  ### This is of course a contrived example. We want to know how <u>**_you_**</u> would:

  1. Design the API
  1. Design the Backing Data Store
  1. Implement the:
      1. Class Structure
      1. Calculations
  
  ---

</details>

<details>
  <summary>Assumptions</summary>

  <br>

  **_You can make the following assumptions_**:
  * All employees are paid $2000 per paycheck <u>**_before_**</u> deductions
  * There are <u>**_26_**</u> paychecks in a year
</details>

---

