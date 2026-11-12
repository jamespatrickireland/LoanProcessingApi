export type CreateApplicationRequest = {
    borrowerName: string
    borrowerAddress: Address
    requestedLoanAmount: number
}

export type Address = {
    street: string
    city: string
    state: string
    zip: string
}