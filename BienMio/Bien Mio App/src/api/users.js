import axios from "axios"
import { config } from "../settings"


export const getAllUsers = (token) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/users`,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        }
			)
			.then((res) => {
				const data = res.data;

				resolve(data.data);
			})
			.catch((err) => {
				reject(err)
			});
	});
};

export const getUser = (token, id) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/users/${id}`,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        }
			)
			.then((res) => {
				const data = res.data;

				resolve(data.data);
			})
			.catch((err) => {
				reject(err)
			});
	});
};

export const editUser = (id, data, token) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/users/${id}`,
				data,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        }
			)
			.then((res) => {
				const data = res.data;
				resolve({...data.data});
			})
			.catch((err) => {
				reject(err)
			});
	});
};

