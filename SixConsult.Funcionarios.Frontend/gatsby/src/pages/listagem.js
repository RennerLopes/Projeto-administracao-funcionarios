import React, { useState, useEffect, useCallback } from 'react';
import { DataGrid, GridActionsCellItem } from '@mui/x-data-grid';
import Layout from '../components/Layout';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { navigate } from 'gatsby';

export default function Listagem() {
  const [Data, setData] = useState();

  const deleteUser = useCallback(
    (id) => () => {
      setTimeout(() => {
        fetch(`https://localhost:5001/funcionario/${id}`, {
          method: 'delete',
        })
          .then((msg) => {
            setData((prevData) => prevData.filter((row) => row.id !== id));
            console.log(msg);
          })
          .catch((err) => {
            console.log('erro ao remover: ' + err);
          });
      });
    },
    []
  );

  // const editUser = useCallback(
  //   (data) => () => {
  //     console.log('ttt: ' + JSON.stringify(data));
  //   },
  //   []
  // );

  const columns = React.useMemo(
    () => [
      { field: 'id', headerName: 'ID', width: 70 },
      { field: 'nome', headerName: 'Nome', width: 130 },
      { field: 'sobrenome', headerName: 'Sobrenome', width: 130 },
      {
        field: 'fullName',
        headerName: 'Nome Completo',
        sortable: false,
        width: 200,
        valueGetter: (params) =>
          `${params.row.nome || ''} ${params.row.sobrenome || ''}`,
      },
      {
        field: 'numeroChapa',
        headerName: 'Chapa',
        width: 200,
      },
      {
        field: 'email',
        headerName: 'Email',
        minWidth: 400,
      },
      {
        field: 'actions',
        headerName: 'Ações',
        type: 'actions',
        width: 120,
        getActions: (params) => [
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            onClick={() => {
              navigate('/editar/', {
                state: { data: params.row },
              });
            }}
          />,
          <GridActionsCellItem
            icon={<DeleteIcon />}
            label="Delete"
            onClick={deleteUser(params.id)}
          />,
        ],
      },
    ],
    [deleteUser]
  );

  useEffect(() => {
    fetch(`https://localhost:5001/funcionario`)
      .then((response) => response.json())
      .then((resultData) => {
        setData(resultData);
      });
  }, []);

  return (
    <Layout>
      <div style={{ height: 650, width: '100%', marginTop: 40 }}>
        <DataGrid
          rows={Data}
          columns={columns}
          pageSize={10}
          rowsPerPageOptions={[5]}
        />
      </div>
    </Layout>
  );
}
