import * as React from 'react';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Link from '../components/Link';
import Layout from '../components/Layout';

export default function Index() {
  return (
    <Layout>
      <Box sx={{ my: 4 }}>
        <Typography variant="h4" component="h1" gutterBottom>
          Gatsby example
        </Typography>
        <Link to="/about" color="secondary">
          Go to the about page
        </Link>
      </Box>
    </Layout>
  );
}
