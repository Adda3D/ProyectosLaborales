import axios from "axios"
import { config } from "../settings"


export const getAllProcesses = (token) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/processes`,
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

export const getProcess = (token, id) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/processes/${id}`,
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

export const editProcess = (id, data, token) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/processes/${id}`,
				data,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
						'Content-Type': 'multipart/form-data'
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