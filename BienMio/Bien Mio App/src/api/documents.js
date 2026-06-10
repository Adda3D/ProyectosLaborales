import axios from "axios"
import { config } from "../settings"


export const getAllDocuments = (token) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/documents`,
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

export const getDocument = (token, id) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/documents/${id}`,
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

export const editDocument = (id, data, token) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/documents/${id}`,
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

