import { useState } from 'react'
import type { SubmitEvent } from 'react'
import type { CreateApplicationRequest } from './types/Application'
import './App.css'

function App() {
    const [application, setApplication] = useState<CreateApplicationRequest>({
        borrowerName: '',
        borrowerAddress: {
            street: '',
            city: '',
            state: '',
            zip: ''
        },
        requestedLoanAmount: 0
    });

    async function handleSubmit(e: SubmitEvent<HTMLFormElement>) {
    e.preventDefault();
    const response = await fetch('http://localhost:5223/Application/Create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(application)
    });

}

  return (
    <>
    <h1>Loan Processing Application</h1>
    <form onSubmit={handleSubmit}>
      <label htmlFor="borrowerName"> Borrower Name:</label>  
    <input id="borrowerName" value={application.borrowerName}
  onChange={(e) => setApplication({...application, borrowerName: e.target.value})}
/>
<label htmlFor="requestedLoanAmount"> Requested Loan Amount:</label> 
    <input id="requestedLoanAmount" type="number" value={application.requestedLoanAmount}
  onChange={(e) => setApplication({...application, requestedLoanAmount: Number(e.target.value)})}
/>

<label htmlFor="street"> Street:</label> 
    <input id="street" value={application.borrowerAddress.street}
  onChange={(e) => setApplication({...application, borrowerAddress: {...application.borrowerAddress, street: e.target.value}})}
/>
<label htmlFor="city"> City:</label> 
  <input id="city" value={application.borrowerAddress.city}
  onChange={(e) => setApplication({...application, borrowerAddress: {...application.borrowerAddress, city: e.target.value}})}
/>
<label htmlFor="state"> State:</label> 
<input id="state" value={application.borrowerAddress.state}
  onChange={(e) => setApplication({...application, borrowerAddress: {...application.borrowerAddress, state: e.target.value}})}
/>
<label htmlFor="zip"> Zip:</label> 
<input id="zip" value={application.borrowerAddress.zip}
  onChange={(e) => setApplication({...application, borrowerAddress: {...application.borrowerAddress, zip: e.target.value}})}
/>
<button type="submit">Submit</button>
</form>
    </>
)}

export default App
