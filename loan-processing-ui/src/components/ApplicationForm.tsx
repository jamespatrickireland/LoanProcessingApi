
import { useState } from 'react'
import './ApplicationForm.css'
import type { SubmitEvent } from 'react'
import type { CreateApplicationRequest } from '../types/Application.ts'
import type { ApplicationResponse } from '../types/ApplicationResponse.ts';

function ApplicationForm() {
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

    const [result, setResult] = useState<ApplicationResponse | null>(null);

    async function handleSubmit(e: SubmitEvent<HTMLFormElement>) {
        e.preventDefault();
        const response = await fetch('http://localhost:5223/Application/Create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(application)
        });
        const data: ApplicationResponse = await response.json();
        setResult(data);

        
    };

    return (
        <>
        <form className="application-form" onSubmit={handleSubmit}>
            <h1>Loan Processing Application</h1>
            <div className="form-field">
                <label htmlFor="borrowerName"> Borrower Name:</label>
                <input id="borrowerName" value={application.borrowerName}
                    onChange={(e) => setApplication({ ...application, borrowerName: e.target.value })}
                />
            </div>
            <div className="form-field">
                <label htmlFor="requestedLoanAmount"> Requested Loan Amount:</label>
                <input id="requestedLoanAmount" type="number" value={application.requestedLoanAmount}
                    onChange={(e) => setApplication({ ...application, requestedLoanAmount: Number(e.target.value) })}
                />
            </div>
            <div className="form-field">
                <label htmlFor="street"> Street:</label>
                <input id="street" value={application.borrowerAddress.street}
                    onChange={(e) => setApplication({ ...application, borrowerAddress: { ...application.borrowerAddress, street: e.target.value } })}
                />
            </div>
            <div className="form-field">
                <label htmlFor="city"> City:</label>
                <input id="city" value={application.borrowerAddress.city}
                    onChange={(e) => setApplication({ ...application, borrowerAddress: { ...application.borrowerAddress, city: e.target.value } })}
                />
            </div>
            <div className="form-field">
                <label htmlFor="state"> State:</label>
                <input id="state" value={application.borrowerAddress.state}
                    onChange={(e) => setApplication({ ...application, borrowerAddress: { ...application.borrowerAddress, state: e.target.value } })}
                />
            </div>
            <div className="form-field">
                <label htmlFor="zip"> Zip:</label>
                <input id="zip" value={application.borrowerAddress.zip}
                    onChange={(e) => setApplication({ ...application, borrowerAddress: { ...application.borrowerAddress, zip: e.target.value } })}
                />
            </div>

            <button type="submit">Submit</button>
        </form>
        {result && (
            <div className="application-result">
                <h2>Application Result</h2>
                <p>ID: {result.id}</p>
                <p>Status: {result.status}</p>
                <p>Interest Rate: {result.interestRate}</p>
                <p>Decision Reason: {result.decisionReason}</p>
            </div>
    )}
    </>
    )
}

export default ApplicationForm