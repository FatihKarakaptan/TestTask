import { CreditApplicationRequest } from "../../Models/CreditApplication/Request/CreditApplicationRequest";
import axios from 'axios';

export const GetCreditApplication = (data: CreditApplicationRequest) => {
    //Give Controller Address
    return axios.post("http://localhost:50244/api/CreditApplication", data);
}
