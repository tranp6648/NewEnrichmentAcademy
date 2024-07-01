import axios from "axios";
import { CreateAccount } from '../api/api'
const baseurl = CreateAccount();
export const ShowAccount = async () => {
    const response = await axios.get(`${baseurl}ShowAccountTeacher`);
    return response.data;
}
export const AddAccount = async (Account) => {
    try {
        const response = await fetch(`${baseurl}AddAccountTeacher`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Account),
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in AddAccount:', error.message);
        throw error;
    }
}
export const LoginAccount = async (Email, Password) => {
    try {
        const response = await fetch(`${baseurl}LoginAccount/${Email}/${Password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in Login:', error.message);
        throw error;
    }
}
export const ResetPassword = async (Email, Password) => {
    try {
        const response = await fetch(`${baseurl}ResetPassword/${Email}/${Password}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in Reset:', error.message);
        throw error;
    }
}
export const CheckOTP = async (Email, OTP) => {
    try {
        const response = await fetch(`${baseurl}CheckOTP/${Email}/${OTP}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in CheckOTP:', error.message);
        throw error;
    }
}
export const ForgetPassword = async (Email) => {
    try {
        const response = await fetch(`${baseurl}ForgotPassword/${Email}`, {
            method: 'PUT',
            eaders: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;

    } catch (error) {
        console.error('Error in Forget:', error.message);
        throw error;
    }
}
export const ApproveAccount = async (ID, Email) => {
    try {
        const response = await fetch(`${baseurl}ApproveActive/${ID}/${Email}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        if (!response.ok) {
            return data;
        }
        return data;
    } catch (error) {
        console.error('Error in Approve:', error.message);
        throw error;
    }
}