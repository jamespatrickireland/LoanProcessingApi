
import type { Address } from './Application.ts'

export type ApplicationResponse = {
    id: number
    status: ApplicationStatus
    interestRate: number
    createdDate: Date
    borrowerName: string
    borrowerAddress: Address
    requestedLoanAmount: number
    decisionReason?: string

}

export type ApplicationStatus = 'Approved' | 'Rejected'

