type CreateApplicationRequest = {
    borrowerName: string
    borrowerAddress: Address
    requestedLoanAmount: number
}

type Address = {
    street: string
    city: string
    state: string
    zip: string
}