import axios from "axios"
import { config } from "../settings"


export const signIn = (data) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/signin`,
				data
			)
			.then((res) => {
				const data = res.data;
				
				resolve({...data.data});
			})
			.catch((err) => {
				reject(err)
			});
	});
} 

export const signUp = (data) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/signup`,
				data
			)
			.then((res) => {
				const data = res.data;
				
				resolve({...data.data});
			})
			.catch((err) => {
				reject(err)
			});
	});
} 